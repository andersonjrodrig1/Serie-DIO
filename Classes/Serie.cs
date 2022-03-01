using Dio.Series.Enums;
using Dio.Series.Interfaces.Base;
using System;

namespace Dio.Series.Classes
{
    public class Serie : Entity
    {
        private GenderEnum Gender { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool IsExclude { get; set; }

        public Serie(int id, GenderEnum gender, string title, string description, int year)
        {
            this.Id = id;
            this.Gender = gender;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.IsExclude = false;
        }

        public Serie(GenderEnum gender, string title, string description, int year)
        {
            this.Gender = gender;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.IsExclude = false;
        }

        public override string ToString() => 
            $"Código: {this.Id}, Gênero: {this.Gender}, Titulo: {this.Title}, Descrição: {this.Description}, Ano de Inicio: {this.Year}, Excluido: {this.IsExclude}";

        public string GetTitle() => this.Title;

        public int GetId() => this.Id;

        public void Exclude() => this.IsExclude = true;
    }
}
