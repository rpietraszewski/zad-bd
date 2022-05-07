using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace zad3.Models
{       
    public class Check
    {
        public int Id { get; set; }
        [Display(Name = "Rok: ")]
        [Range(1898, 2022,
        ErrorMessage = "Oczekiwana wartość {0} z zakredu {1} i {2}."), Required(ErrorMessage = "Pole jest obowiązkowe")]
        public int? Number { get; set; }
        [Display(Name = "Imie: ")]
        [MaxLength(100)]
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        public string? Name { get; set; }
        [MaxLength(100)]
        [Display(Name = "Nazwisko: ")]
        public string? LastName { get; set; }
        [Display(Name = "Data: ")]
        public DateTime Now { get; set; } = DateTime.UtcNow;

        public override string ToString()
        {
            if(((Number % 4 == 0) && (Number % 100 != 0)) || (Number % 400 == 0))
            { 
                return "Przestepny"; 
            }
            else
            {
                return "Nieprzestepny";
            }
        }


        public (string, string) getOutput()
        {
            if (Number >= 1898 && Number <= 2022 && Name.Length > 0 && Name.Length <= 100)
            {
                string outMessage = (Name + " urodził się w " + Number + " roku. To był rok przestępny.");
                string outMethod = "success";
                if (((Number % 4 == 0) && (Number % 100 != 0)) || (Number % 400 == 0))
                {
                    return (outMessage, outMethod);
                }
                else
                {
                    outMessage = (Name + " urodził się w " + Number + " roku. To nie był rok przestępny.");
                    return (outMessage, outMethod);
                }
            }
            else
            {
                string outMessage = "Podano liczbe spoza oczekiwanego zakresu";
                string outMethod = "warning";
                return (outMessage, outMethod);
            }

        }

    }
}
