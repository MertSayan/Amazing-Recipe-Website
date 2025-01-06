using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using YemekUygulamasıDto.RecipeDtos;

namespace YemekWebUI.TagHelpers
{
    public class RecipeListTagHelper :TagHelper
    {
        public List<RecipeAreaDto> Recipes { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Ana wrapper div
            output.TagName = "div";
            output.Attributes.Add("class", "recepie_area");

            // İçerik container
            TagBuilder containerDiv = new TagBuilder("div");
            containerDiv.AddCssClass("container");

            // Başlık
            TagBuilder header = new TagBuilder("h1");
            header.AddCssClass("d-flex justify-content-center");
            header.InnerHtml.Append("En beğenilen tariflerimiz");
            containerDiv.InnerHtml.AppendHtml(header);

            // Boşluk
            containerDiv.InnerHtml.AppendHtml("<br /><br /><br />");

            // Tariflerin olduğu row
            TagBuilder rowDiv = new TagBuilder("div");
            rowDiv.AddCssClass("row");

            foreach (var recipe in Recipes)
            {
                // Her tarif için bir sütun
                TagBuilder colDiv = new TagBuilder("div");
                colDiv.AddCssClass("col-xl-4 col-lg-4 col-md-6");

                // Tarif kartı
                TagBuilder recipeDiv = new TagBuilder("div");
                recipeDiv.AddCssClass("single_recepie text-center");

                // Resim div'i
                TagBuilder imageDiv = new TagBuilder("div");
                imageDiv.AddCssClass("KendimAyarladim");
                TagBuilder imageTag = new TagBuilder("img");
                imageTag.Attributes.Add("src", recipe.RecipeImageUrl);
                imageTag.Attributes.Add("alt", "");
                imageDiv.InnerHtml.AppendHtml(imageTag);

                recipeDiv.InnerHtml.AppendHtml(imageDiv);

                // Başlık
                TagBuilder titleTag = new TagBuilder("h3");
                titleTag.InnerHtml.Append(recipe.Title);
                recipeDiv.InnerHtml.AppendHtml(titleTag);

                // Açıklama
                TagBuilder descriptionTag = new TagBuilder("p");
                string shortDescription = recipe.Description.Length > 50
                    ? recipe.Description.Substring(0, 50) + "..."
                    : recipe.Description;
                descriptionTag.InnerHtml.Append(shortDescription);
                recipeDiv.InnerHtml.AppendHtml(descriptionTag);

                // Link
                TagBuilder linkTag = new TagBuilder("a");
                linkTag.AddCssClass("line_btn");
                linkTag.Attributes.Add("href", $"/RecipeDetail/Index?recipeId={recipe.RecipeId}");
                linkTag.InnerHtml.Append("Tarifin tam halini gör");
                recipeDiv.InnerHtml.AppendHtml(linkTag);

                colDiv.InnerHtml.AppendHtml(recipeDiv);
                rowDiv.InnerHtml.AppendHtml(colDiv);
            }

            containerDiv.InnerHtml.AppendHtml(rowDiv);
            output.Content.SetHtmlContent(containerDiv);
        }
    }

}
