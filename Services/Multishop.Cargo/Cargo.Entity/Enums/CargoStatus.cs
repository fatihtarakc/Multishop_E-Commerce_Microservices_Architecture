using System.ComponentModel.DataAnnotations;

namespace Cargo.Entity.Enums
{
    public enum CargoStatus
    {
        [Display(Name = "Cargo was given to cargo company.")]
        Given = 1,
        [Display(Name = "Cargo is in the transfer process.")]
        TransferProcess,
        [Display(Name = "Cargo is at the delivery branch.")]
        DeliveryBranch,
        [Display(Name = "Cargo is in distribution.")]
        Distribution,
        [Display(Name = "Cargo was delivered.")]
        Delivered
    }
}