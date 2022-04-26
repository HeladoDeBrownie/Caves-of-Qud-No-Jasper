using static XRL.World.Parts.helado_NoJasper_CurseTarget; // GetStateKey

namespace XRL.World.Parts
{
    public class helado_NoJasper_CursedBook : IPart
    {
        public string Attribute = "jasper";

        public override bool WantEvent(int ID, int cascade)
        {
            return ID == InventoryActionEvent.ID;
        }

        public override bool HandleEvent(InventoryActionEvent @event)
        {
            var stateKey = GetStateKey(Attribute);
            var isStateOn = The.Game.GetBooleanGameState(stateKey);

            if (@event.Command != "Read" || isStateOn)
            {
                return false;
            }

            The.Game.SetBooleanGameState(stateKey, true);
            UI.Popup.Show("Laughter echoes in the distance.");
            return true;
        }
    }
}
