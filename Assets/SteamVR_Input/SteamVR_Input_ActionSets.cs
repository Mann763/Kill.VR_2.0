//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Valve.VR
{
    using System;
    using UnityEngine;
    
    
    public partial class SteamVR_Actions
    {
        
        private static SteamVR_Input_ActionSet_HVR p_HVR;
        
        public static SteamVR_Input_ActionSet_HVR HVR
        {
            get
            {
                return SteamVR_Actions.p_HVR.GetCopy<SteamVR_Input_ActionSet_HVR>();
            }
        }
        
        private static void StartPreInitActionSets()
        {
            SteamVR_Actions.p_HVR = ((SteamVR_Input_ActionSet_HVR)(SteamVR_ActionSet.Create<SteamVR_Input_ActionSet_HVR>("/actions/HVR")));
            Valve.VR.SteamVR_Input.actionSets = new Valve.VR.SteamVR_ActionSet[] {
                    SteamVR_Actions.HVR};
        }
    }
}
