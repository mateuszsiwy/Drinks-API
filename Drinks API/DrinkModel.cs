using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

public record class Drink(
    [property: JsonPropertyName("strDrink")] string Name,
    [property: JsonPropertyName("strDrinkThumb")] string Thumbnail,
    [property: JsonPropertyName("idDrink")] string DrinkId);

public record class DrinkResponse(
    [property: JsonPropertyName("drinks")] List<Drink> Content);


internal class DrinkDetailObject
{
    [property: JsonPropertyName("drinks")] public List<DrinkDetail> Content { get; set; }
}

public record class DrinkDetail(
    [property: JsonPropertyName("strDrink")] string Name,
    [property: JsonPropertyName("strDrinkAlternate")] string? DrinkAlternate,
    [property: JsonPropertyName("strTags")] string? Tags,
    [property: JsonPropertyName("strVideo")] string? Video,
    [property: JsonPropertyName("strCategory")] string Category,
    [property: JsonPropertyName("strIBA")] string? Iba,
    [property: JsonPropertyName("strAlcoholic")] string Alcoholic,
    [property: JsonPropertyName("strGlass")] string Glass,
    [property: JsonPropertyName("strInstructions")] string Instructions,
    [property: JsonPropertyName("strInstructionsES")] string? InstructionsES,
    [property: JsonPropertyName("strInstructionsDE")] string InstructionsDE,
    [property: JsonPropertyName("strInstructionsFR")] string? InstructionsFR,
    [property: JsonPropertyName("strInstructionsIT")] string InstructionsIT,
    [property: JsonPropertyName("strInstructionsZH-HANS")] string? InstructionsZHhans,
    [property: JsonPropertyName("strInstructionsZH-HANT")] string? InstructionsZHhant,
    [property: JsonPropertyName("strDrinkThumb")] string Thumbnail,
    [property: JsonPropertyName("strIngredient1")] string Ingredient1,
    [property: JsonPropertyName("strIngredient2")] string? Ingredient2,
    [property: JsonPropertyName("strIngredient3")] string? Ingredient3,
    [property: JsonPropertyName("strIngredient4")] string? Ingredient4,
    [property: JsonPropertyName("strIngredient5")] string? Ingredient5,
    [property: JsonPropertyName("strIngredient6")] string? Ingredient6,
    [property: JsonPropertyName("strIngredient7")] string? Ingredient7,
    [property: JsonPropertyName("strIngredient8")] string? Ingredient8,
    [property: JsonPropertyName("strIngredient9")] string? Ingredient9,
    [property: JsonPropertyName("strIngredient10")] string? Ingredient10,
    [property: JsonPropertyName("strIngredient11")] string? Ingredient11,
    [property: JsonPropertyName("strIngredient12")] string? Ingredient12,
    [property: JsonPropertyName("strIngredient13")] string? Ingredient13,
    [property: JsonPropertyName("strIngredient14")] string? Ingredient14,
    [property: JsonPropertyName("strIngredient15")] string? Ingredient15,
    [property: JsonPropertyName("strMeasure1")] string Measure1,
    [property: JsonPropertyName("strMeasure2")] string? Measure2,
    [property: JsonPropertyName("strMeasure3")] string? Measure3,
    [property: JsonPropertyName("strMeasure4")] string? Measure4,
    [property: JsonPropertyName("strMeasure5")] string? Measure5,
    [property: JsonPropertyName("strMeasure6")] string? Measure6,
    [property: JsonPropertyName("strMeasure7")] string? Measure7,
    [property: JsonPropertyName("strMeasure8")] string? Measure8,
    [property: JsonPropertyName("strMeasure9")] string? Measure9,
    [property: JsonPropertyName("strMeasure10")] string? Measure10,
    [property: JsonPropertyName("strMeasure11")] string? Measure11,
    [property: JsonPropertyName("strMeasure12")] string? Measure12,
    [property: JsonPropertyName("strMeasure13")] string? Measure13,
    [property: JsonPropertyName("strMeasure14")] string? Measure14,
    [property: JsonPropertyName("strMeasure15")] string? Measure15,
    [property: JsonPropertyName("strImageSource")] string? ImageSource,
    [property: JsonPropertyName("strImageAttribution")] string? ImageAttribution,
    [property: JsonPropertyName("strCreativeCommonsConfirmed")] string CreativeCommonsConfirmed,
    [property: JsonPropertyName("dateModified")] string? DateModified
);
