using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SetActionMap : Unit {


    [DoNotSerialize]
    public ControlInput inputTrigger;
    [DoNotSerialize]
    public ControlOutput outputTrigger;
    [DoNotSerialize]
    public ValueInput playerArmature;
    [DoNotSerialize]
    public ValueInput actionMapName;


    protected override void Definition()    {
        //The lambda to execute our node action when the inputTrigger
        //port is triggered.
        inputTrigger = ControlInput("inputTrigger", (flow) =>
        {
            GameObject armature = flow.GetValue<GameObject>(playerArmature);
            string name = flow.GetValue<string>(actionMapName);
            if (armature != null)
            {
                PlayerInput playerInput = armature.GetComponent<PlayerInput>();
                playerInput.SwitchCurrentActionMap(name);
            }
            return outputTrigger;
        });

        outputTrigger = ControlOutput("outputTrigger");
        
        //Making the playerArmature input value port visible,
        //setting the port label name to playerArmature and setting its default value.
        playerArmature = ValueInput<GameObject>("playerArmature", null);
                
        //Making the actionMapName input value port visible,
        //setting the port label name to actionMapName and setting its default value.
        actionMapName = ValueInput<string>("actionMapName", "Player");

        //Specifies that we need the playerArmature value to be
        //set before the node can run.
        Requirement(playerArmature, inputTrigger);
        
        //Specifies that the input trigger port's input exits at the
        //output trigger port.
        //Not setting your succession also dims connected nodes, but
        //the execution still completes.
        Succession(inputTrigger, outputTrigger);
    }
}