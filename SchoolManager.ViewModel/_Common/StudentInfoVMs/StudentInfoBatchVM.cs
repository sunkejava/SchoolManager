using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.Business;


namespace SchoolManager.ViewModel._Common.StudentInfoVMs
{
    public partial class StudentInfoBatchVM : BaseBatchVM<StudentInfo, StudentInfo_BatchEdit>
    {
        public StudentInfoBatchVM()
        {
            ListVM = new StudentInfoListVM();
            LinkedVM = new StudentInfo_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class StudentInfo_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
