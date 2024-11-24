using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.Net.Http.Headers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using BookingSystem.DAL.Common;
using BookingSystem.DAL.ConfigModel;

public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public BasicAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock)
        : base(options, logger, encoder, clock)
    { }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        TokenData _tokenData;

        if (!Request.Headers.ContainsKey("Authorization"))
            return AuthenticateResult.Fail("Missing Authorization Header");

      
            string access_token = Request.Headers[HeaderNames.Authorization].ToString();
            access_token = access_token.Replace("Bearer ", "");

            if (string.IsNullOrEmpty(access_token))
            {
                access_token = Request.Cookies["Access-Token"];
            }

            if (access_token != null)
            {
                // the token is captured in this group
                // as declared in the Regex
                var appsettingbuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
                var Configuration = appsettingbuilder.Build();


                try
                {

                    var handler = new JwtSecurityTokenHandler();
                    handler.ValidateToken(access_token, new TokenValidationParameters
                    {
                        // The signing key must match!
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("TokenAuthentication:SecretKey").Value)),
                        RequireSignedTokens = true,
                        // Validate the JWT Issuer (iss) claim
                        ValidateIssuer = true,
                        ValidIssuer = Configuration.GetSection("TokenAuthentication:Issuer").Value,
                        // Validate the JWT Audience (aud) claim
                        ValidateAudience = true,
                        ValidAudience = Configuration.GetSection("TokenAuthentication:Audience").Value,
                        // Validate the token expiry
                        ValidateLifetime = true,
                        // If you want to allow a certain amount of clock drift, set that here:
                        ClockSkew = TimeSpan.Zero,
                        TokenDecryptionKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("TokenAuthentication:TokenEncryptionKey").Value))
                    }, out SecurityToken tokenS);

                    JwtSecurityToken tokenJS = (JwtSecurityToken)tokenS;
                    _tokenData = GeneralDataAccess.GetTokenData(tokenJS);

                    string Role = tokenJS.Claims.First(claim => claim.Type == "role").Value;
                    // create claims array from the model
                    var claims = GeneralDataAccess.GetClaims(_tokenData);

                    // generate claimsIdentity on the name of the class
                    var claimsIdentity = new ClaimsIdentity(claims,
                                nameof(BasicAuthenticationHandler));

                    // generate AuthenticationTicket from the Identity
                    // and current authentication scheme
                    var ticket = new AuthenticationTicket(
                        new ClaimsPrincipal(claimsIdentity), this.Scheme.Name);

                    // pass on the ticket to the middleware
                    return await Task.FromResult(AuthenticateResult.Success(ticket));
                }
                catch (System.Exception ex)
                {

                    return await Task.FromResult(AuthenticateResult.Fail("TokenParseException"));
                }
            }

            // failure branch
            // return failure
            // with an optional message
            return await Task.FromResult(AuthenticateResult.Fail("Model is Empty"));
        
        
        }
}
