  ¤MPassX2Speed      
W    đ
cleo\MPassX2Speed\settings.iniSettingsEnabled Ö  8  M î˙˙˙  Ö  8   M `˙˙˙ î˙˙˙ Y˙˙˙ Y˙˙˙  
W    
W  
 W  Ö  8  M ˙˙˙
|M   
}M   
~M   
M    Ňţ˙˙    
 W  Ö  8   M Ňţ˙˙   
|M Ů  
}M D 
~M $ 
M   ˙˙˙
VAR    MPassX2Speed_Flag    MPassX2Speed_Enabled    MPassWaitFlag    MPassFlag    FLAG   SRC   {$CLEO .cs}
{$USE INI}
0000:

Thread "MPassX2Speed"

:Vars
$MPassX2Speed_Flag = 0
$MPassX2Speed_Enabled = 0
read_memory $MPassWaitFlag 0x1571004 size 4 vp 0

:ActivationCheck
wait 0
0AF0: $MPassX2Speed_Enabled = read_int_from_ini_file "cleo\MPassX2Speed\settings.ini" section "Settings" key "Enabled"
if
$MPassX2Speed_Enabled == 1
jf @Vars


:Start
wait null
if
$MPassX2Speed_Enabled == 0
then
goto @Vars
else
goto @Start_02
end

:Start_02
wait 0
var
$MPassWaitFlag: array 4 of int
end
read_memory $MPassWaitFlag 0x1571004 size 4 vp 0
$MPassWaitFlag = 4500
write_memory 0x1571004 size 4 value $MPassWaitFlag virtual_protect 0
read_memory $MPassFlag 0x1571000 size 1 vp 0
if
$MPassFlag == 1
jf @Start
write_memory 0x4D897C size 1 value 0x90 virtual_protect 0
write_memory 0x4D897D size 1 value 0x90 virtual_protect 0
write_memory 0x4D897E size 1 value 0x90 virtual_protect 0
write_memory 0x4D897F size 1 value 0x90 virtual_protect 0
goto @End

:End
wait 0
$MPassX2Speed_Flag = 1
read_memory $MPassFlag 0x1571000 size 1 vp 0
if
$MPassFlag == 0
jf @End
$MPassX2Speed_Flag = 0
write_memory 0x4D897C size 1 value 0xD9 virtual_protect 0
write_memory 0x4D897D size 1 value 0x44 virtual_protect 0
write_memory 0x4D897E size 1 value 0x24 virtual_protect 0
write_memory 0x4D897F size 1 value 0x0C virtual_protect 0
goto @Start

0A93: terminate_this_custom_script  __SBFTR 