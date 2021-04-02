using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Basic.SubjectInfoVMs
{
    public partial class SubjectInfoListVM : BasePagedListVM<SubjectInfo_View, SubjectInfoSearcher>
    {

        protected override IEnumerable<IGridColumn<SubjectInfo_View>> InitGridHeader()
        {
            return new List<GridColumn<SubjectInfo_View>>{
                this.MakeGridHeader(x => x.Code),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<SubjectInfo_View> GetSearchQuery()
        {
            var query = DC.Set<SubjectInfo>()
                .CheckContain(Searcher.Code, x=>x.Code)
                .CheckContain(Searcher.Name, x=>x.Name)
                .Select(x => new SubjectInfo_View
                {
				    ID = x.ID,
                    Code = x.Code,
                    Name = x.Name,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class SubjectInfo_View : SubjectInfo{

    }
}
