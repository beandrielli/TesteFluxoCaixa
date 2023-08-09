using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Xml.Linq;

namespace TesteFluxoCaixa.Shared
{
    public enum MoveType
    {
        [Display(Name = "Crédito")]
        Credit = 1,
        [Display(Name = "Débito")]
        Debit = 2
    }

    public static class EnumExtensions
    {
        public static string? GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
              .GetMember(enumValue.ToString())
              .First()
              .GetCustomAttribute<DisplayAttribute>()
              ?.GetName();
        }
    }

}
