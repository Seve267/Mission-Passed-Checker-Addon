  �MPassFlagSys     �
 W     �
 W  �
W    L�
W    �
 W  �
W  �
��   �
��   �
��    �
��  $ � 8  � 8   8   T#8 $  M ����    �
W  �
 W    �
��   �
��     �
 W   �����
VAR    MPassFlag    MPassWaitFlag    TrackID    AudioFlag    TimerEndOffset    TimerStartOffset 	   FLAG   SRC �  {$CLEO .cs}
0000:
thread "MPassFlagSys"

:Reset
wait 0
$MPassFlag = 0
write_memory 0x1571000 size 1 val $MPassFlag vp 0

:Vars
$MPassFlag = 0
write_memory 0x1571000 size 1 val $MPassFlag vp 0
read_memory $MPassWaitFlag 0x1571004 size 4 vp 0
var
$MPassWaitFlag: array 4 of int
end
$MPassWaitFlag = 7500
write_memory 0x1571004 size 4 val $MPassWaitFlag vp 0

:StartInitialise
wait 0
read_memory $MPassFlag 0x1571000 size 1 vp 0
read_memory $MPassWaitFlag 0x1571004 size 4 vp 0
read_memory $TrackID 0xB606E4 size 1 vp 0
read_memory $AudioFlag 0xB606E5 size 1 vp 0
read_memory $TimerEndOffset 0xB606F8 size 4 vp 0
read_memory $TimerStartOffset 0xB606E8 size 4 vp 0
if and
$TrackID == 183
$AudioFlag == 0
$TimerEndOffset == 9044
$TimerStartOffset == 0
jf @StartInitialise
wait 0
$MPassFlag = 0x01
read_memory $MPassWaitFlag 0x1571004 size 4 vp 0
write_memory 0x1571000 size 1 val $MPassFlag vp 0
wait $MPassWaitFlag
write_memory 0xB606E4 size 1 val 0x00 vp 0
write_memory 0xB606E8 size 4 val 0x01 vp 0
$MPassFlag = 0x00
write_memory 0x1571000 size 1 val $MPassFlag vp 0
goto @StartInitialise
 

0A93: terminate_this_custom_scriptI  __SBFTR 