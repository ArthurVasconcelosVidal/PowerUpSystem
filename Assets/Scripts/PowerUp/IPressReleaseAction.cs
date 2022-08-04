using UnityEngine.InputSystem;

public interface IPressReleaseAction{
    void OnButtonPressed(object sender, InputAction.CallbackContext buttonContext);
    void OnButtonReleased(object sender, InputAction.CallbackContext buttonContext);
}
