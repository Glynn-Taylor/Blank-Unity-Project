# Blank Unity Project Template

A project template with some basic changes to project settings and useful editor script. If an editor script is in the third party folder it was not written by me and will have the source on the first line of the file.

## Project Settings Changes
* Linear color space
* Better AA on most settings, since forward MSAA is really cheap
* Increased gravity on horizontal/vertical inputs
* Force Text on serialization for better git serialization

## Extra files / changes
* Model post-processor, prevents unity from importing extra materials and a few other common settings
* Texture post-processor, automatically configures and textures with "ui." or "icon." in the name to ui sprites
* uGUI tools by Senshi for snapping anchors to corners.
* A slightly expanded gitignore that doesn't stage lightmap or reflection probe data

I'm thinking of adding more editor tools and post processing templates.