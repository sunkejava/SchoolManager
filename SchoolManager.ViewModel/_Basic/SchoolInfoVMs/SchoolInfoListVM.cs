using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Basic.SchoolInfoVMs
{
    public partial class SchoolInfoListVM : BasePagedListVM<SchoolInfo_View, SchoolInfoSearcher>
    {

        protected override IEnumerable<IGridColumn<SchoolInfo_View>> InitGridHeader()
        {
            return new List<GridColumn<SchoolInfo_View>>{
                this.MakeGridHeader(x => x.Code),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.EnglishName),
                this.MakeGridHeader(x => x.PinyinName),
                this.MakeGridHeader(x => x.SimplePinyinName),
                this.MakeGridHeader(x => x.SimpleName),
                this.MakeGridHeader(x => x.Contacts),
                this.MakeGridHeader(x => x.Phone),
                this.MakeGridHeader(x => x.TypeOfEducation),
                this.MakeGridHeader(x => x.Address),
                this.MakeGridHeader(x => x.TypeOfUrbanAndRural),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<SchoolInfo_View> GetSearchQuery()
        {
            var query = DC.Set<SchoolInfo>()
                .CheckContain(Searcher.Code, x=>x.Code)
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckContain(Searcher.SimpleName, x=>x.SimpleName)
                .CheckContain(Searcher.Contacts, x=>x.Contacts)
                .CheckEqual(Searcher.TypeOfEducation, x=>x.TypeOfEducation)
                .CheckEqual(Searcher.TypeOfUrbanAndRural, x=>x.TypeOfUrbanAndRural)
                .Select(x => new SchoolInfo_View
                {
				    ID = x.ID,
                    Code = x.Code,
                    Name = x.Name,
                    EnglishName = x.EnglishName,
                    PinyinName = x.PinyinName,
                    SimplePinyinName = x.SimplePinyinName,
                    SimpleName = x.SimpleName,
                    Contacts = x.Contacts,
                    Phone = x.Phone,
                    TypeOfEducation = x.TypeOfEducation,
                    Address = x.Address,
                    TypeOfUrbanAndRural = x.TypeOfUrbanAndRural,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class SchoolInfo_View : SchoolInfo{

    }
}
