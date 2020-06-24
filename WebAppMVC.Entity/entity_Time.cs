using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Entity
{
    public class entity_Time
    {
        [Display(Name = "Id")]
        public int TimeID { get; set; }

        [Required(ErrorMessage = "Informe o nome do time.")]
        public string Time { get; set; }

        [Required(ErrorMessage = "Informe o estado do time.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Informe as cores do time.")]
        public string Cores { get; set; }

    }
}
