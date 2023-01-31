using System.ComponentModel.DataAnnotations;

namespace ExpensesTracker.Util
{
    public enum EnumCategory
    {
        [Display(Name = "Not categorized")]
        NotCategorized = 0,
        [Display(Name = "Food")]
        Food = 1,
        [Display(Name = "Transport")]
        Transport = 2,
        [Display(Name = "Job")]
        Job = 3,
        [Display(Name = "Bill")]
        Bill = 4
    }
}
