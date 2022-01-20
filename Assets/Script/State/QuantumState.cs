namespace Script.State {
    public class QuantumState : State
    {
        // Start is called before the first frame update
        private int _layer;
        public override void StateEnterHook() {
            _layer = service.player.gameObject.layer;
            service.player.gameObject.layer = 6;
        }

        public override void StateExitHook() {
            service.player.gameObject.layer = 0;
        }

        public override void UpdateHook() {
            
        }
    }
}
