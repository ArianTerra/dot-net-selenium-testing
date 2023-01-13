# Lab7.Selenium

This is a project for uni. Here I'm testing Selenium features with .NET.
After launch it will open this site (https://www.goldtoe.com), then it will sign in and create a wish list.

## How to launch project

1. Clone this repository or download as zip file and unzip it.
2. Create an account for our test subject (https://www.goldtoe.com/login.php). You can use fake email.
3. Create appsettings.json like that:
```json
{
  "email": "your email",
  "password": "your password"
}
```
Set "Copy to output directory" to "Always" for the appsettings.json file so ConfigurationBuilder would find it. Your .csporj file should have this section:
```xml
<ItemGroup>
  <None Update="appsettings.json">
    <CopyToOutputDirectory>Always</CopyToOutputDirectory>
  </None>
</ItemGroup>
```
Or forget about that hassle with ConfigurationBuilder and just pass your credentials directly to the 'email' and 'password' variables in code.
4. Build and launch the project.