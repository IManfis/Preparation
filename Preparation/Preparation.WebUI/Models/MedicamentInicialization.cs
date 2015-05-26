using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Preparation.Domain.Concrete;
using Preparation.Domain.Entities;

namespace Preparation.WebUI.Models
{
    public class MedicamentInicialization : DropCreateDatabaseAlways<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            context.Medicaments.Add(new Medicament
            {
                Name = "Уголь активированный",
                Anotation = "Черный порошок без запаха и вкуса. Практически нерастворим в обычных растворителях.",
                Image = "ugol.jpg",
                ActiveSubstance = "Активированный уголь",
                Producer = "Монфарм/Украина",
                ReleaseForm = "Таблетки"
            });
            context.Medicaments.Add(new Medicament
            {
                Name = "Ультоп",
                Anotation = "Фармакологическое действие - ингибирующее протонный насос.",
                Image = "ultop.jpg",
                ActiveSubstance = "Омепразол",
                Producer = "КРКА/Словения",
                ReleaseForm = "Капсулы"
            });
            context.Medicaments.Add(new Medicament
            {
                Name = "Доктор Мом",
                Anotation = "Сироп темно-зеленого цвета с запахом ананаса.",
                Image = "mom.jpg",
                ActiveSubstance = "Имбирь",
                Producer = "Юник Фармасьютикалс/Россия",
                ReleaseForm = "Микстура"
            });

            base.Seed(context);
        }
    }
}