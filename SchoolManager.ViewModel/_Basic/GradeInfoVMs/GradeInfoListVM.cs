using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Basic.GradeInfoVMs
{
    public partial class GradeInfoListVM : BasePagedListVM<GradeInfo_View, GradeInfoSearcher>
    {

        protected override IEnumerable<IGridColumn<GradeInfo_View>> InitGridHeader()
        {
            return new List<GridColumn<GradeInfo_View>>{
                this.MakeGridHeader(x => x.Code),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<GradeInfo_View> GetSearchQuery()
        {
            var query = DC.Set<GradeInfo>()
                .CheckContain(Searcher.Code, x=>x.Code)
                .CheckContain(Searcher.Name, x=>x.Name)
                .Select(x => new GradeInfo_View
                {
				    ID = x.ID,
                    Code = x.Code,
                    Name = x.Name,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class GradeInfo_View : GradeInfo{

    }
}
