#8085 MicroProcessor Simulator

## A basic simulator of 8085 MicroProcessor with 7 Registers, 1 Flag Register, 64KB Memory along with memory Management and Instruction Execution for 4 seperate Instructions 



<h2> REGISTERS </h2>
<ul>
  <li>A - Accumulator</li>
  <li>B - General Purpose</li>
  <li>C - General Purpose</li>
  <li>D - General Purpose</li>
  <li>E - General Purpose</li>
  <li>H - High Address</li>
  <li>L - Low Address </li>
</ul>



<h2> Instructions </h2>

<table border="1">
    <thead>
        <tr>
            <th>Opcode</th>
            <th>Instruction</th>
            <th>Operation</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>0x00</td>
            <td>NOP</td>
            <td>No operation</td>
        </tr>
        <tr>
            <td>0x3E</td>
            <td>MVI A, data</td>
            <td>MVI A, data -> loads into register A</td>
        </tr>
        <tr>
            <td>0x77</td>
            <td>MOV M, A</td>
            <td>MOV M, A -> Store A into memory at address in HL</td>
        </tr>
        <tr>
            <td>0x87</td>
            <td>ADD A</td>
            <td>ADD A -> Add A to itself</td>
        </tr>
    </tbody>
</table>

