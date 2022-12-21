using System.ComponentModel.DataAnnotations;

namespace CursoIndio.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
