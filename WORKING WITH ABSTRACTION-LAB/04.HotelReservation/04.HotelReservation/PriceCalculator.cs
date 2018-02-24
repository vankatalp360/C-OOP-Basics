using System;
using System.Collections.Generic;
using System.Text;

public class PriceCalculator
{
    public decimal totalPrice;
    public decimal price;
    public int nights;
    public SeasonEnum season;
    public DiscountEnum discount;


    public PriceCalculator(string[] input)
    {
        price = decimal.Parse(input[0]);
        nights = int.Parse(input[1]);
        season = Enum.Parse<SeasonEnum>(input[2]);
        discount = DiscountEnum.None;
        if (input.Length == 4)
        {
            discount = Enum.Parse<DiscountEnum>(input[3]);
        }
    }
    public string CalculatePrice()
    {
        var discountPercentage = ((decimal)100 - (int)discount) / 100;
        var tempPrice = price * nights * (int)season;
        totalPrice = tempPrice * discountPercentage;
        return totalPrice.ToString("F2");
    }
}
