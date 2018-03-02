# ASP.NET MVC with Angular 2+
This are steps followed to integrate Angular 2+ with ASP.NET MVC.
1)	Create a new empty project with MVC and API templete
2)	Download and extract the angular quick start from GitHub(https://github.com/angular/quickstart)
3)	Copy all the contents of the extracted quick start to the same folder containing the *.csproj file
4)	From the solution explorer, click on show all and include all the files or atleast the below files/folder:-
      a)	 Src/app
      b)	Src/styles.css
      c)	Src/index.html
      d)	Package.json
      e)	Src/tsconfig.json
      f)	tslint.json
5)	Install the packages. This can be done from 2 places.
      a)	Visual Studio – Right click on package.json file and click on Restore Package
      b)	CMD- enter the command ‘npm install’
6)	(**Optional) Go to the same folder on the command prompt and enter ‘npm start’. If a browser fires up with a welcome page from Angular, we are good to go for the final steps.
7)	In the src/systemjs.config.js , Change the path proper for npm in system.Config from ‘node_modules/’ to ‘/node_modules’.
8)	Create a Home controller and generate a index view for the same with a layout page.
9)	In the Shared/_Layout.cshtml add the below code in the head section.
      <base href="../../src/">
      <link rel="stylesheet" href="../../src/styles.css">
      <script src="../../node_modules/core-js/client/shim.min.js"></script>
  	  <script src="../../node_modules/zone.js/dist/zone.js"></script>
  	  <script src="../../node_modules/systemjs/dist/system.src.js"></script>
      <script src="../../src/systemjs.config.js"></script>
      <script>
          System.import('main.js').catch(function (err) { console.error(err); });
      </script>
10)	Goto home/index.cshtml file and add the below code.
      <my-app>Loading.......</my-app>


NOW RUN THE CODE 
CONGRATS YOU HAVE SUCCESSFULLY CREATED YOU ANGULAR 2+ INTEGRATED ASP.NET MVC APPLICATION.

