﻿using FCNuvem.FidelizaAluno.API.Models.Interfaces;
using FCNuvem.FidelizaAluno.API.ViewModels.Person;
using FCNuvem.FidelizaAluno.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.ViewModels.Student
{
    public class StudentViewModel : IViewModelAdapter<StudentEntity>
    {
        public int? RA { get; private set; }
        public decimal? EvasionChance { get; internal set; }
        public int? PaymentDay { get; private set; }
        public DateTime? LastPaymentDate { get; private set; }
        public ushort? AmountPaymentPendent { get; private set; }
        public decimal? Distance { get; private set; }
        public decimal? MediaScore { get; private set; }
        public bool? Overdue { get; private set; }
        public decimal Frequency { get; private set; }
        public IEnumerable<ReasonEvasionViewModel> ReasonsEvasion { get; set; }
        public string Name { get; internal set; }
        public int? Id { get; internal set; }

        public PersonViewModel Person { get; set; }

        public void Bind(StudentEntity model)
        {
            throw new NotImplementedException();
        }

        public void Fill(StudentEntity model)
        {
            if (model == null)
                return;

            RA = model.RA;
            EvasionChance = model.EvasionScore;
            PaymentDay = model.PaymentDay;
            LastPaymentDate = model.LastPaymentDate;
            AmountPaymentPendent = model.AmountPaymentPendent;
            Distance = model.Distance;
            MediaScore = model.MediaScore;
            Overdue = model.Overdue;
            Frequency = Calculetefrequency(model.Presence.Where(q => q.Presence).Count(), model.Presence.Count());
            ReasonsEvasion = ((model.EvasionHistory != null && model.EvasionHistory.Count > 0) ?
                                model.EvasionHistory.OrderByDescending(o => o.Date).FirstOrDefault()
                                                    .ReasonEvasion?.Where(t => t.ReasonPercentage > 0)
                                                    .OrderByDescending(r => r.ReasonPercentage)
                                                    .Select(r => new ReasonEvasionViewModel
                                                    {
                                                        Name = r.Reason.Name,
                                                        Percentage = r.ReasonPercentage
                                                    }) : null);

            Person = new PersonViewModel();
            Person.Fill(model.Person);
        }

        private decimal Calculetefrequency(decimal quantity, decimal occurrence)
        {
            if (quantity == 0)
                return 0;

            return quantity / occurrence * 100;
        }
    }
}
