using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {kitchen, fridge_0, fridge_1, kitchen_cheese, kitchen_mustard, kitchen_cheese_mustard, 
						bread_alone, bread_cheese, bread_mustard, cupboard_0, cupboard_1, eat};
	private States myState;
	
	// Use this for initialization
	void Start () {
		myState = States.kitchen;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		
		if(myState == States.kitchen)						{kitchen();}  
		else if(myState == States.fridge_0)					{fridge_0();} 
		else if(myState == States.fridge_1)					{fridge_1();}
		else if(myState == States.kitchen_cheese)			{kitchen_cheese();} 
		else if(myState == States.kitchen_mustard)			{kitchen_mustard();} 
		else if(myState == States.kitchen_cheese_mustard)	{kitchen_cheese_mustard();}
		else if(myState == States.bread_alone)				{bread_alone();} 
		else if(myState == States.bread_cheese)				{bread_cheese();}
		else if(myState == States.bread_mustard)			{bread_mustard();}  
		else if(myState == States.cupboard_0)				{cupboard_0();} 
		else if(myState == States.cupboard_1)				{cupboard_1();} 
		else if(myState == States.eat)						{eat();}
	}
	
	void kitchen (){
			text.text = "Holy dogballs, you are hungry! You needs a samich!\n\n" +
			"There is bread on the counter, fridge full of mystery, " +
			"and a cupboard of curiosities. " +
			"Where do you want to start with your samich?!\n\n" +
			"Press B for bread, F for fridge, C for cupboard.";
		
		if (Input.GetKeyDown(KeyCode.B))		{myState = States.bread_alone;}
		else if(Input.GetKeyDown(KeyCode.F))	{myState = States.fridge_0;}
		else if(Input.GetKeyDown(KeyCode.C))	{myState = States.cupboard_0;}
	}
	
	void fridge_0 (){
		text.text = "You open the fridge. Mysteries are revealed! " +
		"In the fridge you find some of that cheese you like.  You konw the one.\n\n" +
		"Press C to take the cheese. Press R to close the fridge.";
		
		if (Input.GetKeyDown(KeyCode.C))		{myState = States.kitchen_cheese;}
		else if (Input.GetKeyDown(KeyCode.R))	{myState = States.kitchen;}
	}
	
	void fridge_1 (){
		text.text = "You open the fridge. Mysteries are revealed! " +
			"In the fridge you find some of that cheese you like.  That will go nicely with the mustard.\n\n" +
			"Press C to take the cheese. Press R to close the fridge.";
		
		if (Input.GetKeyDown(KeyCode.C))		{myState = States.kitchen_cheese_mustard;}
		else if (Input.GetKeyDown(KeyCode.R))	{myState = States.kitchen_mustard;}
	}
	
	void bread_alone (){
		text.text = "Yep, it's bread, the foundation of any good sandwich. " +
			"But what do you want ON your sandwich?\n\n" +
				"Press R to stop oggling the bread (creep).";
		
		if (Input.GetKeyDown(KeyCode.R))		{myState = States.kitchen;}
	}
	
	void bread_cheese (){
		text.text = "Yep, it's bread, the foundation of any good sandwich. " +
			"But what else do you want ON your sandwich besides cheese?\n\n" +
				"Press R to stop oggling the bread (creep).";
		
		if (Input.GetKeyDown(KeyCode.R))		{myState = States.kitchen_mustard;}
	}
	
	void bread_mustard (){
		text.text = "Yep, it's bread, the foundation of any good sandwich. " +
			"But what else do you want ON your sandwich besides mustard?\n\n" +
				"Press R to stop oggling the bread (creep).";
		
		if (Input.GetKeyDown(KeyCode.R))		{myState = States.kitchen_cheese;}
	}
	
	void cupboard_0 (){
		text.text = "There's mustard in the cupboard! Sweet! " +
			"You are a condiments-first kind of person!\n\n" +
				"Press M to take the mustard. Press R to close the cupboard";
		
		if (Input.GetKeyDown(KeyCode.M))		{myState = States.kitchen_mustard;}
		else if (Input.GetKeyDown(KeyCode.R))	{myState = States.kitchen;}
	}
	
	void cupboard_1 (){
		text.text = "Hells yes! Mustard!\n\n" +
			"Press M to take the mustard. Press R to close the cupboard.";
		
		if (Input.GetKeyDown(KeyCode.M))		{myState = States.kitchen_cheese_mustard;}		
		else if (Input.GetKeyDown(KeyCode.R))	{myState = States.kitchen_cheese;}		
	}
	
	void kitchen_cheese (){
		text.text = "You've got that cheese you like, but now you need condiments...\n\n" +
		"Press C to look in the cupboard.";
		
		if (Input.GetKeyDown(KeyCode.C))		{myState = States.cupboard_1;}
	}

	void kitchen_mustard (){
		text.text = "You've got that badass mustard, but now you need cheese... " + 
		"Condiments do not a sandwich make.  You need fillings, man!\n\n" + 
		"Press B for bread, F for fridge.";
		
		if (Input.GetKeyDown(KeyCode.F))		{myState = States.fridge_1;}
		else if (Input.GetKeyDown(KeyCode.B))	{myState = States.bread_alone;}
	}
		
	void kitchen_cheese_mustard (){
		text.text = "Like the first ape, learning to craft simple tools " +
		"You combine bread with cheese with mustard and create... SANDWICH!!!\n\n" +
		"Press E to eat your badass sandwich";

		if (Input.GetKeyDown(KeyCode.E))		{myState = States.eat;}	
	}
	
	void eat (){
		text.text = "OMG... soooo good. " +
			"But you know what that makes you want... another sandwich!\n\n" +
			"Press S to start making another sandwich";
			
		if (Input.GetKeyDown(KeyCode.S))		{myState = States.kitchen;}
	}
}
