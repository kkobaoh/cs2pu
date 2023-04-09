namespace cs2pu.plant_uml.node
{
    public class Accessibility
    {
        private enum Type
        {
            Public,
            PackagePrivate,
            Private,
            Protected,
            Undefind
        }
        private readonly Type _type;
        public Accessibility(string accessibility)
        {
            switch (accessibility)
            {
                case "public":
                    _type = Type.Public;
                    break;
                case "private":
                    _type = Type.Private;
                    break;
                case "internal":
                    _type = Type.PackagePrivate;
                    break;
                case "protected":
                    _type = Type.Protected;
                    break;
                default:
                    _type = Type.Undefind;
                    Console.WriteLine(accessibility);
                    break;
            }
        }

        public string Serialize()
        {
            switch (_type)
            {
                case Type.Private:
                    return "-";
                case Type.Protected:
                    return "#";
                case Type.PackagePrivate:
                    return "~";
                case Type.Public:
                    return "+";
                default:
                    return string.Empty;
            }
        }
    }
}