using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SchoolManager.Model.BasicInfo;
using WalkingTec.Mvvm.Core;

namespace SchoolManager.DataAccess
{
    public class DataContext : FrameworkContext
    {
        public DbSet<FrameworkUser> FrameworkUsers { get; set; }

        public DbSet<GradeInfo> gradeInfos { get; set; }

        public DbSet<GradeClassInfo> gradeClassInfos { get; set; }

        public DbSet<ProjectInfo> projectInfos { get; set; }

        public DbSet<TitleInfo> titleInfos { get; set; }

        public DbSet<HonorInfo> honorInfos { get; set; }

        public DbSet<Division> divisions { get; set; }

        public DbSet<SchoolInfo> schoolInfos { get; set; }

        public DbSet<PositionInfo> positionInfos { get; set; }

        public DbSet<MajorInfo> majorInfos { get; set; }

        public DbSet<SubjectInfo> subjectInfos { get; set; }

        public DataContext(CS cs)
             : base(cs)
        {
        }

        public DataContext(string cs, DBTypeEnum dbtype)
            : base(cs, dbtype)
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public override async Task<bool> DataInit(object allModules, bool IsSpa)
        {
            var state = await base.DataInit(allModules, IsSpa);
            bool emptydb = false;
            try
            {
                emptydb = Set<FrameworkUser>().Count() == 0 && Set<FrameworkUserRole>().Count() == 0;
            }
            catch { }
            if (state == true || emptydb == true)
            {
                //when state is true, means it's the first time EF create database, do data init here
                //当state是true的时候，表示这是第一次创建数据库，可以在这里进行数据初始化
                var user = new FrameworkUser
                {
                    ITCode = "admin",
                    Password = Utils.GetMD5String("000000"),
                    IsValid = true,
                    Name = "Admin"
                };

                var userrole = new FrameworkUserRole
                {
                    UserCode = user.ITCode,
                    RoleCode = "001"
                };
                Set<FrameworkUser>().Add(user);
                Set<FrameworkUserRole>().Add(userrole);
                //年级信息
                var grade1 = new GradeInfo { Code = "01", Name = "高一年级", IsValid = true };
                var grade2 = new GradeInfo { Code = "02", Name = "高二年级", IsValid = true };
                var grade3 = new GradeInfo { Code = "03", Name = "高三年级", IsValid = true };
                var grade4 = new GradeInfo { Code = "04", Name = "毕业年级", IsValid = true };
                Set<GradeInfo>().AddRange(new GradeInfo[] {
                    grade1,
                    grade2,
                    grade3,
                    grade4,
                });
                //班级信息
                Set<GradeClassInfo>().AddRange(new GradeClassInfo[] {
                    new GradeClassInfo { Code = "01", Name = "高一32班", Grade = grade1, IsValid = true },
                    new GradeClassInfo { Code = "02", Name = "高一33班", Grade = grade1, IsValid = true },
                    new GradeClassInfo { Code = "03", Name = "高一34班", Grade = grade1, IsValid = true },
                    new GradeClassInfo { Code = "04", Name = "高一35班", Grade = grade1, IsValid = true },
                    new GradeClassInfo { Code = "05", Name = "高一36班", Grade = grade1, IsValid = true },
                    new GradeClassInfo { Code = "06", Name = "高二31班(理)", Grade = grade2, IsValid = true },
                    new GradeClassInfo { Code = "07", Name = "高二30班", Grade = grade2, IsValid = true },
                    new GradeClassInfo { Code = "08", Name = "高二29班", Grade = grade2, IsValid = true },
                    new GradeClassInfo { Code = "09", Name = "高二28班(文)", Grade = grade2, IsValid = true },
                    new GradeClassInfo { Code = "10", Name = "高二27班", Grade = grade2, IsValid = true },
                    new GradeClassInfo { Code = "11", Name = "高三26班", Grade = grade3, IsValid = true },
                    new GradeClassInfo { Code = "12", Name = "高三25班(文)", Grade = grade3, IsValid = true },
                    new GradeClassInfo { Code = "13", Name = "高三24班(理)", Grade = grade3, IsValid = true },
                    new GradeClassInfo { Code = "14", Name = "高三23班", Grade = grade3, IsValid = true },
                    new GradeClassInfo { Code = "15", Name = "高三22班(复读)", Grade = grade3, IsValid = true },
                    new GradeClassInfo { Code = "16", Name = "毕业班20级", Grade = grade4, IsValid = true },
                    new GradeClassInfo { Code = "17", Name = "毕业班19级", Grade = grade4, IsValid = true },
                    new GradeClassInfo { Code = "18", Name = "毕业班18级", Grade = grade4, IsValid = true },
                    new GradeClassInfo { Code = "19", Name = "毕业班17级", Grade = grade4, IsValid = true }
                });
                //专业信息
                Set<MajorInfo>().AddRange(new MajorInfo[] {
                    new MajorInfo { Code = "01", Name = "哲学", IsValid = true },
                    new MajorInfo { Code = "0101", Name = "哲学类", IsValid = true },
                    new MajorInfo { Code = "010101", Name = "哲学", IsValid = true },
                    new MajorInfo { Code = "010102", Name = "逻辑学", IsValid = true },
                    new MajorInfo { Code = "010103K", Name = "宗教学", IsValid = true },
                    new MajorInfo { Code = "02", Name = "经济学", IsValid = true },
                    new MajorInfo { Code = "0201", Name = "经济学类", IsValid = true },
                    new MajorInfo { Code = "020101", Name = "经济学", IsValid = true },
                    new MajorInfo { Code = "020102", Name = "经济统计学", IsValid = true },
                    new MajorInfo { Code = "0202", Name = "财政学类", IsValid = true },
                    new MajorInfo { Code = "020201K", Name = "财政学", IsValid = true },
                    new MajorInfo { Code = "020202", Name = "税收学", IsValid = true },
                });
                //科目信息
                Set<SubjectInfo>().AddRange(new SubjectInfo[] {
                    new SubjectInfo { Code = "01", Name = "语文", IsValid = true },
                    new SubjectInfo { Code = "02", Name = "数学", IsValid = true },
                    new SubjectInfo { Code = "03", Name = "英语", IsValid = true },
                    new SubjectInfo { Code = "04", Name = "物理", IsValid = true },
                    new SubjectInfo { Code = "05", Name = "化学", IsValid = true },
                    new SubjectInfo { Code = "06", Name = "生物", IsValid = true },
                    new SubjectInfo { Code = "07", Name = "地理", IsValid = true },
                    new SubjectInfo { Code = "08", Name = "政治", IsValid = true },
                    new SubjectInfo { Code = "09", Name = "体育", IsValid = true },
                    new SubjectInfo { Code = "10", Name = "音乐", IsValid = true },
                    new SubjectInfo { Code = "11", Name = "计算机", IsValid = true },
                    new SubjectInfo { Code = "12", Name = "美术", IsValid = true },
                    new SubjectInfo { Code = "13", Name = "书法", IsValid = true },
                    new SubjectInfo { Code = "14", Name = "历史", IsValid = true },
                });
                //职称管理
                Set<PositionInfo>().AddRange(new PositionInfo[] {
                    new PositionInfo { Code = "01", Name = "三级教师", IsValid = true },
                    new PositionInfo { Code = "02", Name = "二级教师", IsValid = true },
                    new PositionInfo { Code = "03", Name = "一级教师", IsValid = true },
                    new PositionInfo { Code = "04", Name = "高级教师", IsValid = true },
                    new PositionInfo { Code = "05", Name = "正高级教师", IsValid = true },
                });
                //荣誉信息
                Set<HonorInfo>().AddRange(new HonorInfo[] {
                    new HonorInfo { Code = "01", Name = "全国模范教师", IsValid = true },
                    new HonorInfo { Code = "02", Name = "全国优秀教师", IsValid = true },
                    new HonorInfo { Code = "03", Name = "全国优秀教育工作者", IsValid = true },
                    new HonorInfo { Code = "04", Name = "全国教育系统先进工作者", IsValid = true },
                    new HonorInfo { Code = "05", Name = "全国教书育人楷模", IsValid = true },
                    new HonorInfo { Code = "06", Name = "省级优秀教师", IsValid = true },
                    new HonorInfo { Code = "07", Name = "省级骨干教师", IsValid = true },
                    new HonorInfo { Code = "08", Name = "市级优秀班主任", IsValid = true },
                    new HonorInfo { Code = "09", Name = "市级优秀教师", IsValid = true },
                    new HonorInfo { Code = "10", Name = "市级骨干教师", IsValid = true },
                    new HonorInfo { Code = "11", Name = "市级教坛新秀", IsValid = true },
                });
                //职位管理
                Set<TitleInfo>().AddRange(new TitleInfo[]
                {
                    new TitleInfo { Code = "01", Name = "校长", IsValid = true },
                    new TitleInfo { Code = "02", Name = "副校长", IsValid = true },
                    new TitleInfo { Code = "03", Name = "书记", IsValid = true },
                    new TitleInfo { Code = "04", Name = "副书记", IsValid = true },
                    new TitleInfo { Code = "05", Name = "教导主任", IsValid = true },
                    new TitleInfo { Code = "06", Name = "副教导主任", IsValid = true },
                    new TitleInfo { Code = "07", Name = "财务主任", IsValid = true },
                    new TitleInfo { Code = "08", Name = "年级组长", IsValid = true },
                    new TitleInfo { Code = "09", Name = "班主任", IsValid = true },
                    new TitleInfo { Code = "10", Name = "副班主任", IsValid = true },
                    new TitleInfo { Code = "11", Name = "代理班主任", IsValid = true },
                    new TitleInfo { Code = "12", Name = "实习教师", IsValid = true },
                });
                //培训项目
                Set<ProjectInfo>().AddRange(new ProjectInfo[] {
                    new ProjectInfo { Code = "01", Name = "信息化教学能力提升", IsValid = true },
                    new ProjectInfo { Code = "02", Name = "心理学研修班", IsValid = true },
                    new ProjectInfo { Code = "03", Name = "财经商贸", IsValid = true },
                    new ProjectInfo { Code = "04", Name = "服务与管理", IsValid = true },
                    new ProjectInfo { Code = "05", Name = "电子技术应用", IsValid = true },
                    new ProjectInfo { Code = "06", Name = "信息化教学设计与实施", IsValid = true },
                    new ProjectInfo { Code = "07", Name = "数字化教学资源开发", IsValid = true },
                    new ProjectInfo { Code = "08", Name = "专业提升", IsValid = true },
                });
                //5级区划
                Set<Division>().AddRange(new Division[] {
                    new Division { Code = "", ParentCode = "", RuralCode = "", Name = "", IsValid = true},

                });
                await SaveChangesAsync();
            }
            return state;
        }

    }

    /// <summary>
    /// DesignTimeFactory for EF Migration, use your full connection string,
    /// EF will find this class and use the connection defined here to run Add-Migration and Update-Database
    /// </summary>
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            return new DataContext("server=127.0.0.1;database=school_db;user=root;pwd=123456", DBTypeEnum.SqlServer);
        }
    }

}
