using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroEvento.ViewModels
{
    // Atributo de validação customizado para a data
    public class DateNotInPastAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateTime)
            {
                // A data do evento não pode ser anterior à data de hoje
                return dateTime.Date >= DateTime.Now.Date;
            }
            return false;
        }
    }

    public class EventoViewModel
    {
        [Display(Name = "Nome do Evento")]
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(50, ErrorMessage = "O Nome não pode exceder 50 caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Número de Participantes")]
        [Required(ErrorMessage = "O campo Número de Participantes é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O Número de Participantes deve ser maior que zero.")]
        public int NumeroParticipantes { get; set; }

        [Display(Name = "Data do Evento")]
        [Required(ErrorMessage = "O campo Data é obrigatório.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DateNotInPast(ErrorMessage = "A Data não pode ser menor que a data atual.")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O campo Ativo é obrigatório.")]
        public bool Ativo { get; set; }
    }
}