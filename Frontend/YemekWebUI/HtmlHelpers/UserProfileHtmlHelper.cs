using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using YemekUygulamasıDto.UserDtos;

namespace YemekWebUI.HtmlHelpers
{
    public static class UserProfileHtmlHelper
    {
        public static IHtmlContent UserProfileCard(this IHtmlHelper htmlHelper, ResultUserDto user)
        {
            var html = $@"
                <div class='container'>
                    <div class='profile-container text-center'>
                        <img src='{user.UserImageUrl}' alt='User Image' class='profile-img'>
                        <h3>{user.Name} {user.Surname}</h3>
                        <div class='profile-info text-left mt-4'>
                            <div class='form-group'>
                                <label>Email:</label>
                                <p>{user.Email}</p>
                            </div>
                            <div class='form-group'>
                                <label>Şifre:</label>
                                <p>{user.Password}</p>
                            </div>
                            <div class='form-group'>
                                <label>Telefon:</label>
                                <p>{user.Phone}</p>
                            </div>
                            <div class='form-group'>
                                <label>Birth Date:</label>
                                <p>{DateTime.Parse(user.BirthDate, CultureInfo.InvariantCulture).ToString("dd-MM-yyyy")}</p>
                            </div>
                        </div>
                    </div>
                </div>";

            return new HtmlString(html);
        }
    }
}
