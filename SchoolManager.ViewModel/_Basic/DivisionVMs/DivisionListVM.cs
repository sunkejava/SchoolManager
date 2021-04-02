using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Basic.DivisionVMs
{
    public partial class DivisionListVM : BasePagedListVM<Division_View, DivisionSearcher>
    {

        protected override IEnumerable<IGridColumn<Division_View>> InitGridHeader()
        {
            return new List<GridColumn<Division_View>>{
                this.MakeGridHeader(x => x.Code),
                this.MakeGridHeader(x => x.ParentCode),
                this.MakeGridHeader(x => x.RuralCode),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Division_View> GetSearchQuery()
        {
            var query = DC.Set<Division>()
                .CheckContain(Searcher.Code, x=>x.Code)
                .CheckContain(Searcher.ParentCode, x=>x.ParentCode)
                .CheckContain(Searcher.RuralCode, x=>x.RuralCode)
                .CheckContain(Searcher.Name, x=>x.Name)
                .Select(x => new Division_View
                {
				    ID = x.ID,
                    Code = x.Code,
                    ParentCode = x.ParentCode,
                    RuralCode = x.RuralCode,
                    Name = x.Name,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Division_View : Division{

    }
}
