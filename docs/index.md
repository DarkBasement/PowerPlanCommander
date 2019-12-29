<h1>Power Plan Commander</h1>

This tool automatically turns on a specified Windows [Battery] Power Plan when a specified process is found running.
It also restores the original Power Plan when the process ends.

For example: when you run a full screen game, it consumes all single core CPU and, even more, the Turbo Boost makes it even worse. As a result, the laptop goes really hot and loud. Power Plan Commander can change computer power plan to a plan with a limited cpu speed while the game is running. It will return to the original plan after you close the game/app.

<p>Requirements: Windows, .Net framework 4.6, Evevated privileges.</p>

How to install:
<ol>
<li>Create a [Low Performance] Windows power plan. Name it and customize it as you want.<br>
<img src='./images/CreateNewLowPerformancePlan02.png'/>
<li>Leave the original power plan selected.<br>
<img src='./images/CreateNewLowPerformancePlan03.png'/>
<li>Run the PowerPlanCommanderSetup. It will ask for elevated privileges and a path to install.<br>
<img src='./images/Install01.png'/> 
<li>When the installation is complete, a setup window will appear.<br>
<img src='./images/PowerPlanSettings01.png'/> 
<li>Select the power plan you want to use for your application. You may also select a pre-defined process/application that will trigger the plan.<br>
<img src='./images/PowerPlanSettings02.png'/> 
<li>You can also select a process/application from currently running apps or input it manually.<br>
<img src='./images/PowerPlanSettings03.png'/> 
<li>Click Apply button and check the ‘Server Status’.<br>
<img src='./images/PowerPlanSettings04.png'/> 
<li>That’s it! Close the window. From now, every time you run h3wog or chrome your pc will switch to the ‘Low Performance’ plan. And it will switch the plan back when the app is closed.
</ol>

<ol>
<li>Uninstall. Go to the Add or Remove Programs screen and remove it from there.<br>
<img src='./images/Uninstall01.png'/> 
</ol>
