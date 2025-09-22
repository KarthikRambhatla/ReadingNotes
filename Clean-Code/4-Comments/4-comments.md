*Don't comment bad code - rewrite it* - **B.W. Kernighan, P.J. Plaugher**

We write comments when we fail to express through code. The farther a comment from the code, the older it is, more likely it is outdated. So we should always aim to express in code rather comments. 

* Comments do not make up for bad code - better clean the module than comment

* Explain yourself in code. In many cases, it is simply to Create a function that says same thing as comment you want to write

        //chcek to see if employee is eligible for full benefits
        if (employee.flags & HOURLY_FLAG) && (employee.age > 65)
    
    instead of the above you could do below
        
        if (employee.isEligibleForFullBenefits())
* Good Comments - A truly good comment is the one you find a way to not write

    - legal comments - For corporate coding standards, authorship statements
    - informative comments - To explain why something is done.
    - Clarification - For obscure code that we cannot alter
    - Warning of consequences - To warn of side effects, performance issues
    - TODO comments - To mark areas of improvement, still eliminate them, bad to litter code with TODOs
    - Amplification - To explain a piece of code in more detail
    - Documentation comments explaining Public APIs. But they still could be misleading and outdated.

* Bad Comments
     - Mumbling - writing something just because you felt you should. For example, when leaving a catch block empty. You write something but if it is not clearly explaining why you left it empty. If you decide to write, write it well.

     - Redundant comments - comments that are not more informative than code, no intent, no rationale.

     - Misleading comments - Subtle inaccuracies, statements not precise

     - Mandated comments - unnecessary documentation comments clutter up code, obfuscate and propagate lies

     - Journal comments - like a journal, log in each module/file to say they edited it. They were used before source control systems. Now not needed.

     - Noise comments - Restating obvious or writing your frustration and Those that we learn to ignore when scanning code.
     - 