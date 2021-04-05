import i18n from "@/lang";

export const ASSEMBLIES: Array<string> = [
  "add",
  "edit",
  "delete",
  "export",
  "imported"
];

export const TABLE_HEADER: Array<object> = [


    {
        key: "Code",
        label: "代码"
    },
    {
        key: "Name",
        label: "名称"
    },
    {
        key: "TypeOfHonor",
        label: "荣誉类型"
    },
  { isOperate: true, label: i18n.t(`table.actions`), actions: ["detail", "edit", "deleted"] } //操作列
];

export const TypeOfHonorTypes: Array<any> = [
  { Text: "教师", Value: "Teacher" },
  { Text: "学生", Value: "Student" }
];

