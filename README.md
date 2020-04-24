# TopoDroidTranslationHelper

A Windows .NET application to help translating and maintaining [TopoDroid](https://github.com/marcocorvi/topodroid) language files via a visual interface.

Run the application and specify the root of your local TopoDroid source code repository. It will load and parse the `strings.xml` file from the `int18` directory for each language. Select your language and the strings will be displayed for each entry. They can be edited inline but the string editor is more appropriate. Click on the string to open it in the string editor.

This tool is experimental and may lead to information loss. Please backup your local repository files every time before using it.
After testing you can use a visual compare tool to inspect the modified strings.xml file with an old one to view changes.

### Issues:
- the original XML formatting is not maintained in cases where there are extra spaces in the XML tags
  - ex.: ```<string name="button_plot" . . . >Schiță</string>```
- strings marked with UNUSED / OK / NO should not be shown in the editor when navigating
- .XML source selection not corresponding in some cases with the loaded strings
- completion stats not calculated precisely due to UNUSED / OK / NO strings

Currently the `plurals.xml` and `array.xml` files are no supported.


![Interface](https://i.ibb.co/PTY2kjp/topodroid-github-commit-2.jpg)
