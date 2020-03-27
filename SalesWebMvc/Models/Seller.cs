using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Birth Date")] // Esse Anotation altera como aparecerá esse rótulo na pagina do site
        [DataType(DataType.Date)] //formata a data
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] //formata a data
        public DateTime BirthDate { get; set; }

        [Display(Name = "Base Salary")] //formata o rotulo no display da pagina
        [DisplayFormat(DataFormatString = "{0:F2}")] //formata o valor com 2 casas decimais
        public double BaseSalary { get; set; }
        public Department Department { get; set; } //Associação
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>(); //Associação

        //Construtores
        public Seller()
        {

        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        // Métodos customizados

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }
        
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
