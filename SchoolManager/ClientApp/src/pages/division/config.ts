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
        label: "区划代码"
    },
    {
        key: "ParentCode",
        label: "上级区划代码"
    },
    {
        key: "RuralCode",
        label: "城乡类型代码"
    },
    {
        key: "Name",
        label: "名称"
    },
  { isOperate: true, label: i18n.t(`table.actions`), actions: ["detail", "edit", "deleted"] } //操作列
];


