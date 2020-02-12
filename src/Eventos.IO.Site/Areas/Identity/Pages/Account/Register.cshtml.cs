using System;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Eventos.IO.Application.Interfaces;
using Eventos.IO.Application.ViewModels;
using Eventos.IO.Domain.Core.Notifications;
using Eventos.IO.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Eventos.IO.Site.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IOrganizadorAppService _organizadorAppService;
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;
        private readonly IUser _user;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IOrganizadorAppService organizadorAppService,
            IDomainNotificationHandler<DomainNotification> notifications,
            IUser user)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _organizadorAppService = organizadorAppService;
            _notifications = notifications;
            _user = user;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "O nome é requerido")]
            [Display(Name = "Nome")]
            public string Nome { get; set; }

            [Required(ErrorMessage = "O CPF é requerido")]
            [Display(Name = "CPF")]
            [StringLength(11)]
            public string CPF { get; set; }

            [Required(ErrorMessage = "O e-mail é requerido")]
            [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Senha")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirme a senha")]
            [Compare("Password", ErrorMessage = "A senha e a confirmação da senha não coincidem.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddClaimAsync(user, new Claim("Eventos", "Ler"));
                    await _userManager.AddClaimAsync(user, new Claim("Eventos", "Gravar"));
                    var organizador = new OrganizadorViewModel
                    {
                        Id = Guid.Parse(user.Id),
                        Email = user.Email,
                        Nome = Input.Nome,
                        CPF = Input.CPF
                    };

                    _organizadorAppService.Registrar(organizador);

                    if (!OperacaoValida())
                    {
                        await _userManager.DeleteAsync(user);
                        foreach (var error in _notifications.GetNotifications())
                        {
                            ModelState.AddModelError(string.Empty, error.Value);
                        }
                        return Page();
                    }

                    _logger.LogInformation("O usuário criou uma nova conta com senha.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirme seu e-mail",
                        $"Por favor, confirme sua conta <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private bool OperacaoValida()
        {
            return !_notifications.HasNotifications();
        }
    }
}
