﻿using FlexCel.Core;
using FlexCel.XlsAdapter;
using MT.Data.BO;
using MT.Library.Extensions;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.Rep
{
    public class SinhMaVachCaoRepository : BaseReportRepository
    {
        public SinhMaVachCaoRepository(IUnitOfWork unitOfWork):base(unitOfWork)
        {

        }

    }
}