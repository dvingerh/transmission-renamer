# 🧲 Transmission Renamer
Bulk torrent file renamer using Transmission's RPC protocol. Upon completion of this tool its aim is to make renaming large amounts of torrent files faster and easier, using a variety of custom rules which are applied to the selected torrent files.

Currently this project is **unfinished**, not all core functionality has been implemented and there are still a large amount of bugs to fix.
An overview of implemented and planned functionality can be found below, as well as some screenshots showcasing the user interface.


#### Note
When (eventually) all functionalities and rules are implemented in this project I may start doing a .NET Core rewrite of this application with the aim of providing cross-platform support and improved code overall. Very little planning was done for this particular project, but should I one day start with the full rewrite preparations will be made where they are most important.


![](/Screenshots/spacer.png?raw=true)

## To-do

#### Core Functionality
| Logic                                | Not Implemented | Implemented |
|--------------------------------------|:---------------:|:-----------:|
| Connection with Transmission session |                 |      x      |
| Session Torrents Overview            |                 |      x      |
| Torrent Selection                    |                 |      x      |
| Torrent Files Overview               |                 |      x      |
| Torrent File Selection               |                 |      x      |
| Rename Rules Overview                |                 |      x      |
| Rule Rename Preview                  |                 |      x      |
| Rule Creation                        |                 |      x      |
| Rule Editing                         |                 |      x      |
| Rule Reordering                      |                 |      x      |
| Send Rename command to Transmission  |        x        |             |
| Must-Have level Error Handling       |        x        |             |

![](/Screenshots/spacer.png?raw=true)

#### Planned Rules
| Rule Type           | Not Implemented | Implemented | Description                                                                        |
|---------------------|:---------------:|:-----------:|------------------------------------------------------------------------------------|
| Insert              |                 |      x      | Insert string at a given position or text in the filename.                         |
| Delete              |                 |      x      | Delete characters from a start / end position or delimiter.                        |
| Remove              |        x        |             | Remove one or more occurrences of a string in the filename.                        |
| Replace             |        x        |             | Replace one or more occurrences of a string in the filename with another string.   |
| Clean               |        x        |             | Remove pre-defined or user-defined characters from the filename.                   |
| Regular Expressions |        x        |             | Replace a character or string matched by the Regular Expression with a new string. |

![](/Screenshots/spacer.png?raw=true)

#### Additional Plans
| Plan                                 | Not Done | Done |
|--------------------------------------|:--------:|:----:|
| Add Unit Tests                       |    x     |      |
| Expand Error Checking / Handling     |    x     |      |
| Code Refactoring                     |    x     |      |

![](/Screenshots/spacer.png?raw=true)

### Screenshots
*The interface is subject to change and does not represent the final product.*

![](/Screenshots/spacer.png?raw=true)

##### Connect to session

![Connect to session](/Screenshots/transmission-renamer_session.png?raw=true "Connect to session")

![](/Screenshots/spacer.png?raw=true)

##### Session Torrents Overview

![Session Torrents Overview](/Screenshots/transmission-renamer_torrents.png?raw=true "Session Torrents Overview")

![](/Screenshots/spacer.png?raw=true)

##### Torrent File Selection

![File selection](/Screenshots/transmission-renamer_files.png?raw=true "File selection")

![](/Screenshots/spacer.png?raw=true)

##### New / Edit Rule Window

![New / Edit Rule Window](/Screenshots/transmission-renamer_newrule.png?raw=true "New / Edit Rule Window")

![](/Screenshots/spacer.png?raw=true)

##### Rename Rules Overview

![Rename Rules Overview](/Screenshots/transmission-renamer_rulepreview.png?raw=true "Rename Rules Overview")

![](/Screenshots/spacer.png?raw=true)
