<h2> Mission Passed Checker Mod Development</h2>

This mod will check if the current mission is passed.


Q: How to get the value if the mission is passed

A: In SB, 
FIrst: You need to read the memory address at 0x1571000

Second: Add the text label with formatted ~1~, and show the text label with the variable of the memory address.

Note: To create your own custom Mission Passed Checker, you need a script editor tool "Sanny Builder 3"

Note: If you want to create your mod quickly, you can use the MPassFlag.cs file as to get the $MPassFlag Variable easily.

This is the code example with MPassFlag.cs loader

Code Example:
:AddTextLabel
add_text_label "VALUE0" "Value = ~1~"

:DefineVar
$MPassFlag = 0

:StartCode
wait 0
readmem $MPassFlag 0x1171000 size 1 vp 0
show_text_1number 'VALUE0' $MPassFlag
goto @StartCode

-End of code-

This code uses an Memory allocation inside the gta_sa.exe memory addresses for the shared variables.

Hexadecimal lookup:

hex
01 00 00 00 00 00 00 00
end

That's it for the document.
I hope you understand this Doc.

@Seve267, Created this Document since 2024.
