namespace MyApp {
    public enum CustomProperty {
        Reference = 0,
        Department = 1,
        DocumentType = 2,
        CustomerName = 3,
        Category = 4,
        ExpireDate = 5,
        DocumentDate = 6,
        CustomerCode = 7,
        Site = 8
    }

    public static class Extensions {
        public static string ToText(this CustomProperty property) {
            switch (property) {
                case CustomProperty.CustomerName:
                    return "CustomProperty:CustomerName";
                case CustomProperty.Department:
                    return "CustomProperty:Department";
                case CustomProperty.DocumentType:
                    return "CustomProperty:DocumentType";
                case CustomProperty.Reference:
                    return "CustomProperty:Reference";
                case CustomProperty.Category:
                    return "CustomProperty:Category";
                case CustomProperty.ExpireDate:
                    return "ExpireDate:ExpireDate";
                case CustomProperty.DocumentDate:
                    return "CustomProperty:DocumentDate";
                case CustomProperty.CustomerCode:
                    return "CustomProperty:CustomerCode";
                case CustomProperty.Site:
                    return "DoHome:Branch";
                default:
                    return "";
            }
        }
    }
}