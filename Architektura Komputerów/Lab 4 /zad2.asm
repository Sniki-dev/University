; 2. Dla zadanej zmiennej 3 cyfrowej, 8-mio bitowej, wypisać ją na ekran (jako liczbę), w odwrotnej kolejności (123 -> 321), z użyciem pętli.

section .text
    org 100h              ; Set the origin for the program to offset 100h (typical for DOS .COM files)

start:
    mov al, 123           ; Load the number 123 into the AL register

start_loop:
    cmp al, 0             ; Check if AL is 0
    je end                ; If AL is 0, jump to the 'end' label to finish the program

    mov bl, 10            ; Load 10 into BL (used as a divisor to extract digits)
    div bl                ; Divide AL by BL
                          ; After division:
                          ;   AL contains the quotient (remaining number after removing the last digit)
                          ;   AH contains the remainder (the current last digit)

    mov dh, al            ; Store the updated quotient (AL) into DH for the next iteration

    add ah, '0'           ; Convert the remainder in AH to its ASCII representation
    mov dl, ah            ; Move the ASCII character to DL (to prepare for printing)
    mov ah, 2             ; Set the DOS interrupt for character output (INT 21h, AH=2)
    int 21h               ; Call DOS to print the character in DL

    xor ax, ax            ; Clear AX (reset both AH and AL)
    mov al, dh            ; Restore the updated quotient (saved in DH) into AL for the next loop

    jmp start_loop        ; Repeat the loop

end:
    mov ax, 4C00h         ; Prepare to terminate the program (INT 21h, AH=4Ch)
    int 21h               ; Call DOS to exit the program
