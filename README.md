# Legacy Code Retreat

Legacy Code Retreat (http://www.legacycoderetreat.com) has the goal of giving programmers an opportunity to practise legacy code rescue techniques without fear. Similar to the wildly successful Code Retreat (http://coderetreat.ning.com), programmers come together for a day, work in pairs, switch pairs frequently, and try various techniques to add tests to and fix legacy code.

Perhaps a little different than the average Code Retreat, in a Legacy Code Retreat, we suggest specific exercises for this legacy code. In general, the goal is to refactor towards a more maintainable design, but you certainly can't rescue this stuff in 45 minutes! (If you can, then screencast it and prove us wrong.)

Here are some ideas for first steps:

* Extract the bodies of the `if` statements into their own little methods. Use those methods to tell a story. Test each method in isolation from the others.
* Turn the `Roll()` method into a Method Object and write tests for it.
* Remove duplication in the parallel collections.
* Write tests for the `Roll()` method then change the method to remove duplication in the tests. (Ignore duplication in the production code.)
* Extract the bodies of the `if` statements into pure functions, meaning that they don't tough the state of the Game.
* Look for bugs (writing tests!) and fix them by test-driving the fixes.

