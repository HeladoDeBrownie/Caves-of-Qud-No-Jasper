namespace XRL.World.Parts
{
    public class helado_NoJasper_CurseTarget : IPart
    {
        public static string GetStateKey(string Attribute)
        {
            return $"helado_NoJasper_Curse_{Attribute}";
        }

        public string Attribute = "jasper";
        public string ReplacementBlueprint = "Ashes";

        public override bool WantEvent(int ID, int cascade)
        {
            return ID == ObjectCreatedEvent.ID;
        }

        public override bool HandleEvent(ObjectCreatedEvent @event)
        {
            if (!The.Game.GetBooleanGameState(GetStateKey(Attribute)))
            {
                return false;
            }

            @event.ReplacementObject = GameObject.create(ReplacementBlueprint);
            return true;
        }
    }
}
