using UnityEngine.InputSystem;

public partial class TestProjectControls
{
   public TestProjectControls(InputActionAsset asset)
	{
		this.asset = asset;

		m_TestProjectMap = asset.FindActionMap("TestProjectMap", true);
		m_TestProjectMap_PcDirectionUp = m_TestProjectMap.FindAction("PcDirectionUp", true);
		m_TestProjectMap_PcDirectionDown = m_TestProjectMap.FindAction("PcDirectionDown", true);
		m_TestProjectMap_PcDirectionLeft = m_TestProjectMap.FindAction("PcDirectionLeft", true);
		m_TestProjectMap_PcDirectionRight = m_TestProjectMap.FindAction("PcDirectionRIght", true);
		m_TestProjectMap_MousePosition = m_TestProjectMap.FindAction("MousePosition", true);
		m_TestProjectMap_CastSpell = m_TestProjectMap.FindAction("CastSpell", true);
		m_TestProjectMap_NextSpell = m_TestProjectMap.FindAction("NextSpell", true);
		m_TestProjectMap_PrevSpell = m_TestProjectMap.FindAction("PrevSpell", true);
	}
}
