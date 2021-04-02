using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Basic.MajorInfoVMs
{
    public partial class MajorInfoListVM : BasePagedListVM<MajorInfo_View, MajorInfoSearcher>
    {

        protected override IEnumerable<IGridColumn<MajorInfo_View>> InitGridHeader()
        {
            return new List<GridColumn<MajorInfo_View>>{
                this.MakeGridHeader(x => x.Code),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<MajorInfo_View> GetSearchQuery()
        {
            var query = DC.Set<MajorInfo>()
                .CheckContain(Searcher.Code, x=>x.Code)
                .CheckContain(Searcher.Name, x=>x.Name)
                .Select(x => new MajorInfo_View
                {
				    ID = x.ID,
                    Code = x.Code,
                    Name = x.Name,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class MajorInfo_View : MajorInfo{

    }
}
