﻿using FCNuvem.FidelizaAluno.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Infrastructure.Repositories.Mappings
{
    internal class CampusEntityMap : EntityMapConfiguration<CampusEntity>
    {
        protected override void OnMapping()
        {
            Builder.HasOneWithOne(l => l.Address);
            Builder.HasOneWithMany(l => l.Institution);
        }
    }
}
