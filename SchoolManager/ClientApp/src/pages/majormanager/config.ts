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
        key: "StartDate",
        label: "开始时间"
    },
    {
        key: "EndDate",
        label: "结束时间"
    },
    {
        key: "Name_view",
        label: "荣誉"
    },
    {
        key: "Name_view2",
        label: "学生"
    },
  { isOperate: true, label: i18n.t(`table.actions`), actions: ["detail", "edit", "deleted"] } //操作列
];


