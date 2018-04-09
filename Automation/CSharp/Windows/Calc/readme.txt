To automate the application you need to add reference of the below 4 dlls.
These references are available under the Assemblies -> Framework tab.

Names of the dlls -->
1) UIAutomationClient
2) UIAutomationClientsideProviders
3) UIAutomationProvider
4) UIAutomationTypes

Although in this program I have used only System.Windows.Automation which is a child of the UIAutomationProvider.dll

Automation object model is provided via System.Windows.Automation.AutomationElement instance associated with a UIElement (said to be “automation peer” of the control).
If you are authoring a custom control, you may want to implement one or more interfaces defined in the UIAutomationProvider.dll under the System.Windows.Automation.Provider namespace to support UI automation.
