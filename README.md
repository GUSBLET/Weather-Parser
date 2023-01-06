# Weather-Parser
##  Description:
This is a weather website that can show you information about weather in the city that you chose. I used technologies such as: "Angle Sharp" (for parsing data from an html page) and "OpenWeather" (artificial intelligence that collects and processes information about weather and gives data back). 

### How is it work:
After correct project setup and start program, you will see main page with input field where you can enter the name of region which weather you are interesting in and push “submit” button. After this action program creates request to “OpenWeather” for receive coordinate of this region, then receives HTTP response and next use by “Angle Sharp” to take JSON string from page and processes the necessary data. Next step it is receive weather data use by coordination. This step similar the last step. After completing all the steps and creation information model, the program returns HTML page with information about weather. 
## Stack:
### Backend:
-	ASP.NET 
-	Angle Sharp 
-	OpenWeather 
### Frontend:
-	HTML
-	CSS
-	Bootstrap

## How to install on your PC
1.	Download Visual studio
2.	Install in “Visual Studio Installer” ASP.NET and web-apps develops package and Net7.0.
3.	Download and install git.
4.	Open git bash.
5.	Choose directory where you want to clone repository with the command:
``` bash 
cd “Path to directory” 
Example: cd E:\Path
```
6. Enter this command for clone repository:
``` bash 
git clone https://github.com/GUSBLET/Weather-Parser.git
```
7. Open the next link and create a new account
8. Open solution file “Weather Parser.sln” with the Visual Studio.
9. Find and copy your Api key in your profile
10. Add to project new user secrets file and type there the next text:
```code
  "AipiToken": "Your Api key"
```
11. Start the program.
