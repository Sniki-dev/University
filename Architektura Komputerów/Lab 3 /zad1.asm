; 1. Dla z góry zadanego ciągu znaków, wypisać pojedynczo wszystkie znaki.

section .txt
	org 100H
	
start:
    mov si, message     ; Load the address of the string "message" into SI

start_loop:
    mov al, [si]        ; Load the character from the si adress
    cmp al, '$'         ; Compare character with $
    je end              ; If character is $ end program

    mov ah, 2           ; Set up DOS function 2 (print character in DL)
    mov dl, al          ; Load the character from the string
    int 21h             

    mov ah, 9           ; DOS function 9 to display a string
    mov dx, newline     ; Load address of text 
    int 21h

    inc si              ; Increment si
    jmp start_loop      ; Back to the beginning of the loop



end:
	mov ax, 4C00h       ; DOS function to terminate program
    int 21h
	
section .data
    newline db 10,13,36 ; Define the newline in memory
	message db "Hello$" ; Define the message in memory
