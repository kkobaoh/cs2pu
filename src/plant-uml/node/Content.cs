namespace cs2pu.plant_uml.node
{
    public class Content
    {
        private readonly ContentAccessibility _accessibility;
        private readonly ContentType _type;

        public Content
        (
            ContentAccessibility accessibility,
            ContentType type
        )
        {
            _type = type;
            _accessibility = accessibility;
        }
    }
}